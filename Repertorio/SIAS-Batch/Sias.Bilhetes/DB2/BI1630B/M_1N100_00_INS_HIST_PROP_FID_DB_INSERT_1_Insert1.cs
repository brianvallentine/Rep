using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1 : QueryBasis<M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIST_PROP_FIDELIZ
            VALUES (:PROPOFID-NUM-IDENTIFICACAO ,
            :WS-DATA-PROC ,
            :PROPOFID-NSAC-SIVPF ,
            :PROPOFID-NSL ,
            'REJ' ,
            'SUS' ,
            99 ,
            :PROPOFID-COD-EMPRESA-SIVPF ,
            :PROPOFID-COD-PRODUTO-SIVPF )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ({FieldThreatment(this.PROPOFID_NUM_IDENTIFICACAO)} , {FieldThreatment(this.WS_DATA_PROC)} , {FieldThreatment(this.PROPOFID_NSAC_SIVPF)} , {FieldThreatment(this.PROPOFID_NSL)} , 'REJ' , 'SUS' , 99 , {FieldThreatment(this.PROPOFID_COD_EMPRESA_SIVPF)} , {FieldThreatment(this.PROPOFID_COD_PRODUTO_SIVPF)} )";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string WS_DATA_PROC { get; set; }
        public string PROPOFID_NSAC_SIVPF { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }

        public static void Execute(M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1 m_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1)
        {
            var ths = m_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}