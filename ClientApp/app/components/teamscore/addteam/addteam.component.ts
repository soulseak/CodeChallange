import { Component } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from "rxjs/Rx";

import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';
@Component({
    selector: 'addteam',
    template: require('./addteam.component.html')
})
export class AddTeamComponent {
    public members: Member[];
    constructor(private http: Http) {
        http.get('/api/Member/Member').subscribe(result => {
            this.members = result.json() as Member[];
        });
    }
    model: Team = {
        TeamId:0,
        Name:'',
        MemberId:0,
        MemberName:'',
        TeamScore:0
    };

    submitted = false;

    onSubmit() { this.submitted = true; }

    public addTeam() {

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.model);
        this.http.post("/api/Team/Create/", body, options)
            .subscribe();
        console.log("done");
    }
}