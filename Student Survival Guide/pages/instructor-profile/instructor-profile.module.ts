import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { InstructorProfilePage } from './instructor-profile';

@NgModule({
  declarations: [
    InstructorProfilePage,
  ],
  imports: [
    IonicPageModule.forChild(InstructorProfilePage),
  ],
})
export class InstructorProfilePageModule {



}
