import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

@inject(HttpClient)
export class SessionWebService {

    constructor(http) {
        this.http = http;
        this.url = 'http://localhost:37432/api/Session';
    }

    getSessions() {
        return this.http.fetch(this.url)
            .then(response => response.json())
            .then(response => {
                for (var session of response) {
                    session.formattedSessionTime = this.updateSessionTimes(session);
                    session.formattedPresenters = this.updateSpeakers(session);
                    session.formattedRooms = this.updateRoomList(session);
                }
                return response;
            })
            .catch(error => console.log(error));
    }

    getById(id) {
        return this.http.fetch(this.url)
            .then(response => response.json())
            .then(response => {
                var sessionId = parseInt(id);
                var item = response.find(x => x.id === sessionId);
                item.formattedSessionTime = this.updateSessionTimes(item);
                item.formattedPresenters = this.updateSpeakers(item);
                item.formattedRooms = this.updateRoomList(item);
                return item;
            })
            .catch(error => console.log(error));
    }

    getSessionsBySpeakerId(id) {
        return this.http.fetch(this.url)
            .then(response => response.json())
            .then(response => {
                var item = response.filter(session => 
                    session.speakers.find(speaker => speaker.id === id));
                for (var session of item) {
                    session.formattedSessionTime = this.updateSessionTimes(session);
                    session.formattedPresenters = this.updateSpeakers(session);
                    session.formattedRooms = this.updateRoomList(session);
                }
                return item;
            })
            .catch(error => console.log(error));
    }
    
    updateRoomList(session) {
        return session.rooms.join(", ");
    }

    updateSpeakers(session) {
        var speakerList = [];
        for (var i = 0; i < session.speakers.length; i++) {
            speakerList.push(session.speakers[i].firstName + 
                " " + session.speakers[i].lastName);
        }
        return speakerList.join(", ");
    }

    updateSessionTimes(session) {
        var result = "N/A";
        if (session !== null) {
            var start = new Date(session.sessionStartTime);
            var stop = new Date(session.sessionEndTime);
            result = start.getHours() +
                ":" +
                (start.getMinutes() < 10 ? '0' : '') +
                start.getMinutes() +
                " - " +
                stop.getHours() +
                ":" +
                (stop.getMinutes() < 10 ? '0' : '') +
                stop.getMinutes();
        }
        return result;
    }


}
