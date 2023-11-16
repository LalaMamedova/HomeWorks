import {makeAutoObservable} from 'mobx';

export default class User{

    constructor () {
        this._IsAuth =false;
        this._user = {};
        makeAutoObservable(this);
    }
    setIsAuth(bool){

        this._IsAuth = bool;
    }
    setUser(user){
        this.user = user;
    }
    getAuth(){
        return this._IsAuth;
    }
    getUser(){
        return this.user;
    }
}