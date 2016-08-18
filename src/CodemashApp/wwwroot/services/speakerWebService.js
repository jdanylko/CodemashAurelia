import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

@inject(HttpClient)
export class SpeakerWebService {

    constructor(http) {
        this.http = http;
        this.url = 'http://localhost:37432/api/Speaker';
    }

    getSpeakers() {
        return this.http.fetch(this.url)
            .then(response => response.json())
            .catch(error => console.log(error));
    }

    getSpeakerById(id) {
        return this.http.fetch(this.url)
            .then(response => response.json())
            .then(response => {
                var item = response.find(x => x.id === id);
                return item;
            })
            .catch(error => console.log(error));
    }

}
