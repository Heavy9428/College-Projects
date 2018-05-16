import { Component, OnDestroy } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {AngularFireDatabase, FirebaseListObservable} from 'angularfire2/database-deprecated';
import { GlobalVars } from '../../shared/models/Glob';
import{Message}from'../../shared/models/message';
import { AuthService } from '../../providers/AuthService';
import { User } from 'firebase/app';
import { Subscription } from 'rxjs/Subscription';
import { DataService } from '../../providers/databaseservice/databaseservice';

/**
 * Generated class for the AddAReviewPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-add-a-review',
  templateUrl: 'add-a-review.html',
})
export class AddAReviewPage implements OnDestroy {
  message: string ='';
  s: FirebaseListObservable<Message[]>;
  i:string;
  i2:string;
  review:Message;
  messages:object[]=[];
  authenticatedUser: User;
  authenticatedUser$: Subscription;

  constructor(public db: AngularFireDatabase,public navCtrl: NavController, public navParams: NavParams, private data: DataService, private auth: AuthService, public single: GlobalVars) 
  {
    this.i=single.getMyGlobalVar();
    this.i2=single.getMyGlobalVar2()
    // this.s=this.db.list('/rating-reviews'+this.i2).valueChanges().subscribe(data =>{
    //   this.messages=data;
    //   });
    this.s = this.data.getMessagesList(this.i2);
    this.s.subscribe((list) => {
      console.log(list);
    });
    console.log(this.s);
      this.authenticatedUser$ = this.auth.getAutenticatedUser().subscribe((user: User) => {
        this.authenticatedUser = user; 
      })
  }
  
  async sendMessage(){
    
    this.review = {
      message: this.message,
      sentby: this.authenticatedUser.uid
    };
    await this.db.list('/rating-reviews'+this.i2).push(this.review);
    this.message = '';
  }
  ionViewDidLoad() {
    console.log('ionViewDidLoad AddAReviewPage');
  }
  ngOnDestroy() {
    this.authenticatedUser$.unsubscribe();
  }
}
