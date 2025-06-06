using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1 : QueryBasis<M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES
            (:DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-IDENTIFICACAO ,
            :DCLPROP-SASSE-BILHETE.PROPSSBI-RENOVACAO-AUTOM ,
            'BI1610B' ,
            CURRENT TIMESTAMP ,
            NULL ,
            :GETPMOIM-NUM-TP-MORA-IMOVEL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES ({FieldThreatment(this.PROPSSBI_NUM_IDENTIFICACAO)} , {FieldThreatment(this.PROPSSBI_RENOVACAO_AUTOM)} , 'BI1610B' , CURRENT TIMESTAMP , NULL , {FieldThreatment(this.GETPMOIM_NUM_TP_MORA_IMOVEL)} )";

            return query;
        }
        public string PROPSSBI_NUM_IDENTIFICACAO { get; set; }
        public string PROPSSBI_RENOVACAO_AUTOM { get; set; }
        public string GETPMOIM_NUM_TP_MORA_IMOVEL { get; set; }

        public static void Execute(M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1 m_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1)
        {
            var ths = m_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_135D0_00_SASSE_BIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}