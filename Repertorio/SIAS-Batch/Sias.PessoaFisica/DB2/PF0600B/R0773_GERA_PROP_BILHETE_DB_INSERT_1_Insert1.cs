using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1 : QueryBasis<R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES
            (:DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-IDENTIFICACAO ,
            :DCLPROP-SASSE-BILHETE.PROPSSBI-RENOVACAO-AUTOM ,
            :DCLPROP-SASSE-BILHETE.PROPSSBI-COD-USUARIO ,
            CURRENT TIMESTAMP ,
            NULL ,
            :DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-TP-MORA-IMOVEL )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES ({FieldThreatment(this.PROPSSBI_NUM_IDENTIFICACAO)} , {FieldThreatment(this.PROPSSBI_RENOVACAO_AUTOM)} , {FieldThreatment(this.PROPSSBI_COD_USUARIO)} , CURRENT TIMESTAMP , NULL , {FieldThreatment(this.PROPSSBI_NUM_TP_MORA_IMOVEL)} )";

            return query;
        }
        public string PROPSSBI_NUM_IDENTIFICACAO { get; set; }
        public string PROPSSBI_RENOVACAO_AUTOM { get; set; }
        public string PROPSSBI_COD_USUARIO { get; set; }
        public string PROPSSBI_NUM_TP_MORA_IMOVEL { get; set; }

        public static void Execute(R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1 r0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1)
        {
            var ths = r0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0773_GERA_PROP_BILHETE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}