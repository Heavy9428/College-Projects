import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { MyApp } from './app.component';
import { ProfListPage } from '../pages/prof-list/prof-list';
import { AccountPage } from '../pages/account/account';
import { AngularFireModule } from 'angularfire2';
import { AngularFireAuthModule } from 'angularfire2/auth';
import { environment } from '../environmants/environment';
import {LoginPage} from '../pages/login/login';
import { ProfListPageModule } from '../pages/prof-list/prof-list.module';
import { LoginPageModule } from '../pages/login/login.module';
import { ReviewPage } from '../pages/review/review';
import { ResgisterPage } from '../pages/resgister/resgister';
import { AngularFireDatabaseModule } from 'angularfire2/database-deprecated';
import { InstructorProfilePageModule } from '../pages/instructor-profile/instructor-profile.module';
import { InstructorProfilePage } from '../pages/instructor-profile/instructor-profile';
import { GlobalVars } from '../shared/models/Glob';
import { FirebaseServiceProvider } from '../providers/firebase-service/firebase-service';
import { DataService } from '../providers/databaseservice/databaseservice';
import { AuthService } from '../providers/AuthService';



@NgModule({
  declarations: [
    MyApp,
    AccountPage,
    ReviewPage,
    ResgisterPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireAuthModule, // imports firebase/auth, only needed for auth features,
    ProfListPageModule,
    LoginPageModule,
    AngularFireDatabaseModule,
    InstructorProfilePageModule,
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    ProfListPage,
    AccountPage,
    LoginPage,
    ReviewPage,
    ResgisterPage,
    InstructorProfilePage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    ProfListPage,
    GlobalVars,
    FirebaseServiceProvider,
    DataService,
    AuthService,
    

  ]
})
export class AppModule {}
