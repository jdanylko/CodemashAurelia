import {SpeakerWebService} from '../services/speakerWebService';
import {inject} from 'aurelia-framework';

@inject(SpeakerWebService)
export class Speakers {

    constructor(speakerService) {
        this.speakerService = speakerService;
    }
    
    activate() {
        this.speakerService.getSpeakers()
            .then(data => {
                this.speakerList = data;
            });
    }
}