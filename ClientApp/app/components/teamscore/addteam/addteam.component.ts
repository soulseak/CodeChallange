import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import { Member } from '../Member';
import { Team } from '../Team';
import { Match } from '../Match';
import { teamscoreService} from '../teamscore.service'
@Component({
    selector: 'addteam',
    providers: [teamscoreService],
    template: require('./addteam.component.html')
})
export class AddTeamComponent /*implements OnInit*/ {
    public members: Member[];
    constructor(http: Http) {
        http.get('/api/Member/Member').subscribe(result => {
            this.members = result.json() as Member[];
        });
    }
    //constructor(private _teamscoreService: teamscoreService) { }

    //getMembers() {
    //    this._teamscoreService.getMembers().then(members => this.members = members);
    //}

    //ngOnInit(): void {
        
    //    this.getMembers();
    //}
}