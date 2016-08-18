import {SessionWebService} from '../services/sessionWebService';
import {inject} from 'aurelia-framework';

@inject(SessionWebService)
export class SessionDetails {

    constructor(service) {
        this.service = service;
    }
    
    activate(params) {
        this.service.getById(params.id)
            .then(session => {
                this.session = session;
            });
    }
}