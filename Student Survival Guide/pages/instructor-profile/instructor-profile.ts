import { Component} from '@angular/core';
import { IonicPage, NavController, NavParams, Events } from 'ionic-angular';
import { ProfListPage } from '../prof-list/prof-list';
import { AngularFireDatabase, FirebaseListObservable} from "angularfire2/database-deprecated"; 
import { Observable } from 'rxjs/Observable';
import { GlobalVars } from '../../shared/models/Glob';
import {App} from 'ionic-angular';

@IonicPage()
@Component({
  selector: 'page-instructor-profile',
  templateUrl: 'instructor-profile.html',
})


export class InstructorProfilePage 
{

profLisRef$: FirebaseListObservable<any[]>;
s:string;
  constructor(private db: AngularFireDatabase,
    public navCtrl: NavController, public navParams: NavParams, public singleton:GlobalVars, private app :App)
    {
      this.s=this.singleton.getMyGlobalVar();
      this.profLisRef$ = this.db.list(this.s);
    }

  ionViewDidLoad() {
    console.log('ionViewDidLoad InstructorProfilePage');
  }

  goBack()
  {
    this.app.getRootNavs()[0].setRoot(ProfListPage);
  }
}
