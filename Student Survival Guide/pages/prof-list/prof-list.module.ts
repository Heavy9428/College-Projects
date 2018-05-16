import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { ProfListPage } from './prof-list';

@NgModule({
  declarations: [ProfListPage,],
  imports: [IonicPageModule.forChild(ProfListPage),],
})
export class ProfListPageModule {}
