import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { AddAReviewPage } from './add-a-review';

@NgModule({
  declarations: [
    AddAReviewPage,
  ],
  imports: [
    IonicPageModule.forChild(AddAReviewPage),
  ],
})
export class AddAReviewPageModule {}
