import { Component } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from "rxjs/Rx";
import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';

@Component({
    selector: 'addmatch',
    template: require('./addmatch.component.html')
})
export class AddMatchComponent {
    public teams: Team[];

    constructor(private http: Http) {
        http.get('/api/Team/Team').subscribe(result => {
            this.teams = result.json() as Team[];
        });
    }

    model: Match = {
        MatchId: '0',
        Team1Id: '',
        TeamName1: '',
        Team2Id: '',
        TeamName2: '',
        ScoreTeam1: '',
        ScoreTeam2: ''
    };

    submitted = false;

    onSubmit() { this.submitted = true; }
    
    public addMatch() {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.model);
        this.http.post("/api/Match/Create/", body, options)
            .subscribe();
        console.log("done");
    }

}