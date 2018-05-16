import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, App } from 'ionic-angular';
import { User } from "../../shared/models/user";
import { AuthService } from '../../providers/AuthService';
/**
 * Generated class for the ResgisterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-resgister',
  templateUrl: 'resgister.html',
})
export class ResgisterPage {

  user = {} as User;

  constructor(public navCtrl: NavController, public navParams: NavParams,private app: App, private auth: AuthService) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad ResgisterPage');
  }

  async register(user: User) {
    try {
      const result = await this.auth.createUserWithEmailAndPassword(user);
      if (result) {
        this.login(user);
      }
    }
    catch (e) {
      console.error(e);
    }
  }
  async login(user: User) {
    try {
      const result = await this.auth.signInWithEmailAndPassword(user);
      if (result) {
        console.log('hi');
        this.app.getRootNavs()[0].setRoot('UserProfilePage');
      }
    }
    catch (e) {
      console.error(e);
    }
  }
}
