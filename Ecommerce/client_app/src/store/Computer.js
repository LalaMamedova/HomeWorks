import {makeAutoObservable} from 'mobx';

export default class Computer{
    constructor () {
        this._type = [
            {id:1, name:'VideoCart'},
            {id:2, name:'CPU'},
            {id:3, name:'RAM'},
        ];

        this._computer=[
            {
                id:1,
                name:'RTX 5000',
                type:this._type[0],
                GPU:5000,
                CUDA:1000,
                img:'https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp',
            },
            {
                id:2,
                name:'Intel I7-1200',
                type:this._type[0],
                GPU:510,
                CUDA:1000,
                img:'https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp',

            },
            {
                id:3,
                name:'Intel I7-1200',
                type:this._type[0],
                GPU:510,
                CUDA:1000,
                img:'https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp',

            },
            {
                id:4,
                name:'Intel I7-1200',
                type:this._type[0],
                GPU:510,
                CUDA:1000,
                img:'https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp',

            },
            {
                id:5,
                name:'Intel I7-1200',
                type:this._type[0],
                GPU:510,
                CUDA:1000,
                img:'https://cdn-img1.imgworlds.com/assets/a5366382-0c26-4726-9873-45d69d24f819.jpg?key=home-gallery',

            },
            {
                id:6,
                name:'Intel I7-1200',
                type:this._type[0],
                GPU:510,
                CUDA:1000,
                img:'https://media.licdn.com/dms/image/D4E0BAQG-i2j7Q2WFIA/company-logo_200_200/0/1694593111703/img_logo?e=2147483647&v=beta&t=GXoH1LXt9jy32BZy9mCLWxerKUmdGB6xCQStyv7hi34',

            },
            {
                id:7,
                name:'Intel I7-1200',
                type:this._type[0],
                GPU:510,
                CUDA:1000,
                img:'https://media.licdn.com/dms/image/D4E0BAQG-i2j7Q2WFIA/company-logo_200_200/0/1694593111703/img_logo?e=2147483647&v=beta&t=GXoH1LXt9jy32BZy9mCLWxerKUmdGB6xCQStyv7hi34',

            },
         

        ]
        makeAutoObservable(this);
    }
    setType(type){
        this._type = type;
    }
  
    getType(){
        return this._type;
    }
    setComputer(computer){
        this._computer = computer;
    }
  
    getComputer(){
        return this._computer;
    }
}