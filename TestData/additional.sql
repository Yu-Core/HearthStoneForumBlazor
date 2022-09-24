exec sp_attach_single_file_db @dbname = 'testbase1',  --数据库名
    @physname = 'F:testbase1_data.mdf'  --物理文件名