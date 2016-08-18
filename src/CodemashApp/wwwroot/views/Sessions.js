import {SessionWebService} from '../services/sessionWebService';
import {inject} from 'aurelia-framework';

@inject(SessionWebService)
export class Sessions {

    constructor(service) {
        this.service = service;
    }
    
    activate() {
        this.service.getSessions()
            .then(data => {
                this.SessionsList = data;
            });
    }
}