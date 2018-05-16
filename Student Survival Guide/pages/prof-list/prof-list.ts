import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AccountPage } from '../account/account';
import { ReviewPage } from '../review/review';
import { GlobalVars } from '../../shared/models/Glob';


@IonicPage()
@Component({
  selector: 'page-prof-list',
  templateUrl: 'prof-list.html',
})
export class ProfListPage {
  constructor(public navCtrl: NavController, public navParams: NavParams,public single: GlobalVars) {
  }

  openHalversonPage()
  {
    this.single.setMyGlobalVar('/Halverson');
    this.single.setMyGlobalVar2('/DrH');
   
    this.navCtrl.push(ReviewPage);
  }

  openBingPage()
  {
    this.single.setMyGlobalVar('/Bing');
    this.single.setMyGlobalVar2('/DrB');
    this.navCtrl.push(ReviewPage);
  }

  openColmenaresPage(){
    this.single.setMyGlobalVar('/Colmenares');
    this.single.setMyGlobalVar2('/DrC');
    this.navCtrl.push(ReviewPage);
  }

  openGriffinPage(){
    this.single.setMyGlobalVar('/Griffin');
    this.single.setMyGlobalVar2('/DrG');
    this.navCtrl.push(ReviewPage);
  }

  openJohnsonPage(){
    this.single.setMyGlobalVar('/Johnson');
    this.single.setMyGlobalVar2('/DrJ');
    this.navCtrl.push(ReviewPage);
  }

  openPassosPage(){
    this.single.setMyGlobalVar('/Passos');
    this.single.setMyGlobalVar2('/DrP');
    this.navCtrl.push(ReviewPage);
  }

  openSimpsonPage(){
    this.single.setMyGlobalVar('/Simpson');
    this.single.setMyGlobalVar2('/MrS');
    this.navCtrl.push(ReviewPage);
  }

  openStringfellowPage(){
    this.single.setMyGlobalVar('/Stringfellow');
    this.single.setMyGlobalVar2('/DrS');
    this.navCtrl.push(ReviewPage);
  }

  openWuthrichPage(){
    this.single.setMyGlobalVar('/Wuthrich');
    this.single.setMyGlobalVar2('/MrsW');
    this.navCtrl.push(ReviewPage);
  }
  

  openAccountPage()
  {
    this.navCtrl.push(AccountPage)
  }

}
