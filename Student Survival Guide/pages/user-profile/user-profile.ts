import { Component, OnDestroy, OnInit } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {DataService} from '../../providers/databaseservice/databaseservice';
import { AuthService } from '../../providers/AuthService';
import {Profile} from '../../shared/models/Profile';
import { Subscription } from 'rxjs/Subscription';
import { User } from 'firebase/app';


/**
 * Generated class for the UserProfilePage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-user-profile',
  templateUrl: 'user-profile.html',
})
export class UserProfilePage implements OnDestroy, OnInit{

  private authenticatedUser$: Subscription; // observable
  private authenticatedUser: User;
  profile:Profile;
  
  constructor(public navCtrl: NavController, public navParams: NavParams,public data:DataService, private auth: AuthService) {
    this.authenticatedUser$ = this.auth.getAutenticatedUser().subscribe((user: User) => {
      this.authenticatedUser = user;
    })
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad UserProfilePage');
  }

  saveprofile()
  {
    this.data.saveProfile(this.authenticatedUser, this.profile);
    this.navCtrl.setRoot('ProfListPage')

  }
  ngOnDestroy() {
    this.authenticatedUser$.unsubscribe();
  }
  ngOnInit() {
    if (!this.profile) {
      this.profile = {username: ''};
    }
  }
}
