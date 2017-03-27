import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';

@Component({
    selector: 'addmatch',
    template: require('./addmatch.component.html')
})
export class AddMatchComponent {
    public teams: Team[];

    constructor(http: Http) {
        http.get('/api/Team/Team').subscribe(result => {
            this.teams = result.json() as Team[];
        });
    }
}