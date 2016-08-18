import {SpeakerWebService} from '../services/speakerWebService';
import {SessionWebService} from '../services/sessionWebService';
import {inject} from 'aurelia-framework';

@inject(SpeakerWebService, SessionWebService)
export class SpeakerDetails {

    constructor(speakerService, sessionService) {
        this.speakerService = speakerService;
        this.sessionService = sessionService;

    }
    
    activate(params) {
        this.speakerService.getSpeakerById(params.id)
            .then(speaker => {
                this.speaker = speaker;
            });
        this.sessionService.getSessionsBySpeakerId(params.id)
            .then(sessions => {
                this.sessions = sessions;
            });
    }
}
