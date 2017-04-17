Ext.ns('Aitch.ext.Window');

Aitch.ext.Window = Ext.extend(Ext.Window, {
	minimizable:true,
	maximizable:true,
	closeAction:'hide',
	initComponent:function(){
		
		Aitch.ext.Window.superclass.initComponent.call(this);
		
		this.maximized = false;
		this.minimized = false;
		this.orgX = 0;
		this.orgY = 0;
	},// eo initComponent()
	
	isMinimized:function(){
		return this.minimized;
	},// eo isMinimized()
	
	isMaximized:function(){
		return this.maximized;
	},//eo isMaximized
	
	maximize:function(){
		if(this.isMinimized()){
			this.backtoOrgSizeAndPos();
			this.maximized = false;
		}else{
			Aitch.ext.Window.superclass.maximize.call(this);
			this.maximized = true;
		}
	},// eo maximize()
	
	minimize:function(){
		if(this.isMaximized()){
			this.restore();
		}else if(!this.isMinimized() && !this.isMaximized()){
			this.orgX = this.x;
			this.orgY = this.y;
			this.collapse();
			this.setPagePosition(0, window.innerHeight - 30);
			this.minimized = true;
		}else if(this.isMinimized()){
			this.backtoOrgSizeAndPos();
		}
	},// eo minimize()
	
	backtoOrgSizeAndPos:function(){
		this.expand();
		this.setPagePosition(this.orgX, this.orgY);
		this.minimized = false;
		this.maximized = false;
	}// eo backtoOrgSizeAndPos()
	
});//eo Aitch.ext.Window class