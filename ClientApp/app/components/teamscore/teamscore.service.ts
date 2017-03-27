import { Injectable, OnInit } from "@angular/core";
import { Http } from '@angular/http';

import { Member } from './Member';
import { Team } from './Team';
import { Match } from './Match';

@Injectable()

export class teamscoreService implements OnInit {
    public teams: Team[];
    public matches: Match[];
    public members: Member[];
    constructor(private http: Http) {
        this.updateData();
    }
    updateData() {
        this.updateTeams();
        this.updateMembers();
        this.updateMatches();
    }
    updateMembers(): Member[] {
        this.http.get('/api/Member/Member').subscribe(result => {
            this.members = result.json() as Member[];
        });
        return this.members;
    }
    updateTeams() {
        this.http.get('/api/Team/Team').subscribe(result => {
            this.teams = result.json() as Team[];
        });
        return this.teams;
    }
    updateMatches() {
        this.http.get('/api/Match/Match').subscribe(result => {
            this.matches = result.json() as Match[];
        });
        return this.matches;
    }
    getTeams() {
        return Promise.resolve(this.teams);
    }
    getMembers(){
        
        return Promise.resolve(this.members);
    }
    getMatches() {
        return Promise.resolve(this.matches);
    }
    ngOnInit(): void {

        this.updateData();
    }
}
