import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { RatingReviewsPage } from './rating-reviews';

@NgModule({
  declarations: [
    RatingReviewsPage,
  ],
  imports: [
    IonicPageModule.forChild(RatingReviewsPage),
  ],
})
export class RatingReviewsPageModule {}
