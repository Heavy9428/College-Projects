import { Component } from '@angular/core';
import { IonicPage, NavController,NavParams} from 'ionic-angular';
import {App} from 'ionic-angular';
/**
 * Generated class for the ReviewPage tabs.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-review',
  templateUrl: 'review.html'

})
export class ReviewPage 
{
  ratingReviewsRoot = 'RatingReviewsPage';
  instructorProfileRoot = 'InstructorProfilePage';
  addAReviewRoot = 'AddAReviewPage';

  constructor(public navCtrl: NavController,public navParams: NavParams,private app : App) 
  {
    
  }

}

