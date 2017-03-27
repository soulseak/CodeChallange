import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';


@Component({
    selector: 'teams',
    template: require('./teams.component.html')
})
export class TeamsComponent {
    public teams: Team[];

    constructor(http: Http) {
        http.get('/api/Team/Team').subscribe(result => {
            this.teams = result.json() as Team[];
        });
    }


    //constructor(http: Http) {
    //    http.get('/api/teamscore/Team').subscribe(result => {
    //        this.teams = result.json();
    //    });
    //    this.teams.push({ TeamId: "0", Name: "Aachen", member: { MemberId: "0", Name: "Florian" } });
    //}

}