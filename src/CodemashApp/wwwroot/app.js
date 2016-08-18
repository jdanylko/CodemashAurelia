export class App {
    
    configureRouter(config, router) {
        config.title = 'Codemash App';

        config.map([
          { route: ['','codemash'], name: 'codemash', moduleId: './views/Codemash', nav: true, title:'Home'},
          { route: 'speakers', name: 'speakers', moduleId: './views/Speakers', nav: true, title:'Speakers'},
          { route: 'sessions', name: 'sessions', moduleId: './views/Sessions', nav: true, title:'Sessions'},
          { route: 'sessionDetail', name: 'sessionDetail', moduleId: './views/SessionDetails', nav: false, title:'Session Details'},
          { route: 'speakerDetail', name: 'speakerDetail', moduleId: './views/SpeakerDetails', nav: false, title:'Speaker Details'}
        ]);

        this.router = router;
    }
}
