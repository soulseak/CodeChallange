import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';

@Component({
    selector: 'matches',
    template: require('./matches.component.html')
})
export class MatchesComponent {
    public matches: Match[];

    constructor(http: Http) {
        http.get('/api/Match/Match').subscribe(result => {
            this.matches = result.json() as Match[];

        });
    }
}