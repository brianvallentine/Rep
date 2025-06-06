using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R5030_00_SELECT_AU055_DB_SELECT_1_Query1 : QueryBasis<R5030_00_SELECT_AU055_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTH_OPERACAO ,
            NUM_ARQUIVO
            INTO :AU055-DTH-OPERACAO ,
            :AU055-NUM-ARQUIVO
            FROM SEGUROS.AU_HIS_PROP_CONV
            WHERE NUM_PROPOSTA_VC = :WHOST-PROPOSTA-VC
            AND DTH_OPERACAO = :SISTEMAS-DATA-MOV-ABERTO
            AND IND_OPERACAO = 'CON'
            AND COD_CONGENERE = :WHOST-CONGENERE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTH_OPERACAO 
							,
											NUM_ARQUIVO
											FROM SEGUROS.AU_HIS_PROP_CONV
											WHERE NUM_PROPOSTA_VC = '{this.WHOST_PROPOSTA_VC}'
											AND DTH_OPERACAO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND IND_OPERACAO = 'CON'
											AND COD_CONGENERE = '{this.WHOST_CONGENERE}'";

            return query;
        }
        public string AU055_DTH_OPERACAO { get; set; }
        public string AU055_NUM_ARQUIVO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_PROPOSTA_VC { get; set; }
        public string WHOST_CONGENERE { get; set; }

        public static R5030_00_SELECT_AU055_DB_SELECT_1_Query1 Execute(R5030_00_SELECT_AU055_DB_SELECT_1_Query1 r5030_00_SELECT_AU055_DB_SELECT_1_Query1)
        {
            var ths = r5030_00_SELECT_AU055_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5030_00_SELECT_AU055_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5030_00_SELECT_AU055_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU055_DTH_OPERACAO = result[i++].Value?.ToString();
            dta.AU055_NUM_ARQUIVO = result[i++].Value?.ToString();
            return dta;
        }

    }
}