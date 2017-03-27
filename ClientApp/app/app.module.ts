import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { TeamscoreComponent } from './components/teamscore/teamscore.component';
import { AddMatchComponent } from './components/teamscore/addmatch/addmatch.component';
import { AddMemberComponent } from './components/teamscore/addmember/addmember.component';
import { AddTeamComponent } from './components/teamscore/addteam/addteam.component';
import { MatchesComponent } from './components/teamscore/matches/matches.component';
import { TeamsComponent } from './components/teamscore/teams/teams.component';
import { MembersComponent } from './components/teamscore/members/members.component';



@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        TeamscoreComponent,
        AddMatchComponent,
        AddMemberComponent,
        AddTeamComponent,
        MatchesComponent,
        TeamsComponent,
        MembersComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'teamscore', component: TeamscoreComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
