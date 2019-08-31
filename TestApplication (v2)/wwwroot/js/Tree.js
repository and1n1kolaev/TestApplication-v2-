Vue.component('track-item', {
    template: '#track-item-template',
    props: {
        track: Object
    },
    data:
        function () {
            return {
                like: false,
                dislike: false,
            }
        },  
    methods:
    {
        likeHandler: function () {

            debugger;
            if (this.like && !this.dislike) {
                this.track.rating--;
                if (this.track.isFavorite)
                {
                    this.favoriteHandler();
                }
            }
            else if (!this.like && this.dislike) {
                this.track.rating++;
                this.track.rating++;
            }
            else if (!this.like && !this.dislike) {
                this.track.rating++;
                
            }

       
            this.like = !this.like;
            this.dislike = false;
            this.trackInfoPost();
           
        },
        dislikeHandler: function () {
     
            if (this.like && !this.dislike) {
                this.track.rating--;
                this.track.rating--;
            }
            else if (!this.like && this.dislike) {
                this.track.rating++;
            }
            else if (!this.like && !this.dislike) {
                this.track.rating--;
            }
            this.dislike = !this.dislike;
            this.like = false
            this.trackInfoPost();


        },
        favoriteHandler: function () {
    
            this.track.isFavorite = !this.track.isFavorite;
            this.track.isFavorite ?
                $.notify("Трек '" + this.track.name + "' добавлен в избранное", "success") :
                $.notify("Трек '" + this.track.name + "' удален из избранного", "info");
            this.trackInfoPost();
        },
        trackInfoPost: function () {
            $.post('/Home/PostTrackInfo/', this.track)
                .done(() => {
                    return true;
                })
                .fail((err) => {
                    $.notify("Ошибка: " + err);
                    return false;
                });
        }
    }
})

Vue.component('tree-item', {
    template: '#tree-item-template',
    props: {
        item: Object
    },
    data: function () {
        return {
            isOpen: false
        }
    },
    computed: {
        isFolder: function () {
            return this.item.album &&
                this.item.album.length
        }
    },
    methods: {
        toggle: function () {
            if (this.isFolder) {
                this.isOpen = !this.isOpen
            }
        },
        detail: function (element) {
            this.$emit('node-change', element);
        }
    }
})

var MusicApp = new Vue({
    el: '#MusicApp',
    data() {
        return {
            treeData: [],
            tracks: [],
            searchString: ''
        };
    },
    mounted() {
        this.refreshData();
    },
    computed: {
        filtered: function () {
            debugger;

            this.refreshData();
            if (this.searchString === '') return this.treeData;
            return treeFilter(this.treeData, this.searchString);
        }
    },
    methods: {
        refreshData: function () {
            $.get('/Home/GetTree')
                .done(response => { this.treeData = response; })
                .fail(err => { $.notify("Ошибка: " + err.statusText) });
        },
        changenode: function (element) {
            if (!element.album) {
                $.get('/Home/GetTracks?albumId=' + element.id)
                    .done(response => { response ? this.tracks = response : null })
                    .fail(err => { $.notify("Ошибка: " + err.statusText) });
            }
        }
    }
})


function treeFilter(data, filterStr) {
    if (!data) return [];
    $.each(data, function (index, el) {
        let text = el.name.toLowerCase();
        if (el.album) el.album = treeFilter(el.album, filterStr);

        let isVisible = (el.album ? el.album.length > 0 : false) 
            || text.indexOf(filterStr.toLowerCase()) > -1;

        if (!isVisible) el.hidden = true;
       
    });  
    return $.grep(data, function (el) { return !el.hidden; });   
}


