const tour = new Shepherd.Tour({
    useModalOverlay: true,
    defaultStepOptions: {
      cancelIcon: {
        enabled: true
      },
      classes: 'tour-window',
      scrollTo: { behavior: 'smooth' }
    },
  });
  
tour.addStep({
    title: 'مرحبا!',
    text: `هذه صفحة النادي اللي فيها معلومات التواصل مع ادارة النادي واعضائه، بالاضافة الى مقالات النادي`,
    buttons: [
        {
        action() {
            return this.next();
        },
        text: 'التالي'
        }
    ]
});

tour.addStep({    
    title: 'ادارة النادي',
    text: `تقدر تتواصل مع ادارة النادي من هنا`,
    attachTo: {
        element: '#clubManagersTable',
        on: 'bottom'
      },
    scrollTo: { behavior: 'smooth', block: 'center' },
    buttons: [
        {
            action() {
                return this.back();
            },
            classes: 'shepherd-button-secondary',
            text: 'السابق'
        },
        {
            action() {
                return this.next();
            },
            text: 'التالي'
        }
    ]
});

tour.addStep({    
    title: 'المقالات',
    text: `قائمة المقالات اللي كتبها اعضاء وادارة النادي`,
    attachTo: {
        element: '#allPostsDiv',
        on: 'top'
      },
      scrollTo: { behavior: 'smooth', block: 'center' },
    buttons: [
        {
            action() {
                return this.back();
            },
            classes: 'shepherd-button-secondary',
            text: 'السابق'
        },
        {
            action() {
                return this.next();
            },
            text: 'انهاء'
        }
    ]
});

tour.addStep({    
    title: 'الانضمام للنادي',
    text: `اضغط على الزر لارسال طلب الى اداري النادي بالانضمام، في حال تم قبولك او كنت من ادارة النادي، تقدر تضغط الزر لنشر مقالة جديد`,
    attachTo: {
        element: '.btn.w-btn.w-btn-primary',
        on: 'bottom'
      },
    scrollTo: { behavior: 'smooth', block: 'center' },
    buttons: [
        {
            action() {
                return this.back();
            },
            classes: 'shepherd-button-secondary',
            text: 'السابق'
        },
        {
            action() {
                return this.next();
            },
            text: 'التالي'
        }
    ]
});

setTimeout(() => {
    // Initiate the tour
    // if(!localStorage.getItem('shepherd-tour-clubs')) {
        tour.start();
        // localStorage.setItem('shepherd-tour-clubs', 'yes');
    // }
}, 1000);
