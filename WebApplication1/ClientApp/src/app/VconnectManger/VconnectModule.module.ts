import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { MaterialModule } from '../shared/material.module';
import { FormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { VconnectAppComponent } from './Vconnect-app.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { MaincontentComponent } from './components/maincontent/maincontent.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { UserService } from '../components/services/user.service';


const routes: Routes = [
  {
    path: '', component: VconnectAppComponent,
    children: [
      { path: ':id', component: MaincontentComponent },
    {path: '', component: MaincontentComponent}
  ]},
  
  {path: '**', redirectTo: ''}
];

@NgModule({
  declarations: [VconnectAppComponent, ToolbarComponent, MaincontentComponent, SidenavComponent],
  providers: [UserService],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    FormsModule,
    FlexLayoutModule,
    RouterModule.forChild(routes)
  ]
})
export class VconnectModule { }
