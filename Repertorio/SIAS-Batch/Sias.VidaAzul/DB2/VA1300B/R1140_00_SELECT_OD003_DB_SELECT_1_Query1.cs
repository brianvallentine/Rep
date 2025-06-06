using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R1140_00_SELECT_OD003_DB_SELECT_1_Query1 : QueryBasis<R1140_00_SELECT_OD003_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PESSOA ,
            NUM_CNPJ ,
            NUM_FILIAL ,
            NUM_DV_CNPJ ,
            NOM_RAZAO_SOCIAL
            INTO :OD003-NUM-PESSOA ,
            :OD003-NUM-CNPJ ,
            :OD003-NUM-FILIAL ,
            :OD003-NUM-DV-CNPJ ,
            :OD003-NOM-RAZAO-SOCIAL
            FROM ODS.OD_PESSOA_JURIDICA
            WHERE NUM_PESSOA = :GE368-NUM-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PESSOA 
							,
											NUM_CNPJ 
							,
											NUM_FILIAL 
							,
											NUM_DV_CNPJ 
							,
											NOM_RAZAO_SOCIAL
											FROM ODS.OD_PESSOA_JURIDICA
											WHERE NUM_PESSOA = '{this.GE368_NUM_PESSOA}'";

            return query;
        }
        public string OD003_NUM_PESSOA { get; set; }
        public string OD003_NUM_CNPJ { get; set; }
        public string OD003_NUM_FILIAL { get; set; }
        public string OD003_NUM_DV_CNPJ { get; set; }
        public string OD003_NOM_RAZAO_SOCIAL { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R1140_00_SELECT_OD003_DB_SELECT_1_Query1 Execute(R1140_00_SELECT_OD003_DB_SELECT_1_Query1 r1140_00_SELECT_OD003_DB_SELECT_1_Query1)
        {
            var ths = r1140_00_SELECT_OD003_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1140_00_SELECT_OD003_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1140_00_SELECT_OD003_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD003_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD003_NUM_CNPJ = result[i++].Value?.ToString();
            dta.OD003_NUM_FILIAL = result[i++].Value?.ToString();
            dta.OD003_NUM_DV_CNPJ = result[i++].Value?.ToString();
            dta.OD003_NOM_RAZAO_SOCIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}