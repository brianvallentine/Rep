using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 : QueryBasis<R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1>
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
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO ,
            0 )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES ({FieldThreatment(this.PROPSSBI_NUM_IDENTIFICACAO)} , {FieldThreatment(this.PROPSSBI_RENOVACAO_AUTOM)} , {FieldThreatment(this.PROPSSBI_COD_USUARIO)} , CURRENT TIMESTAMP , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 0 )";

            return query;
        }
        public string PROPSSBI_NUM_IDENTIFICACAO { get; set; }
        public string PROPSSBI_RENOVACAO_AUTOM { get; set; }
        public string PROPSSBI_COD_USUARIO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1)
        {
            var ths = r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}