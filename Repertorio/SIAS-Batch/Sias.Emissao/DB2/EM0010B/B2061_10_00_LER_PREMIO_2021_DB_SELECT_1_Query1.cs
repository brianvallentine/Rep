using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1 : QueryBasis<B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DIA_VENC_DEMAIS_PARCELAS
            INTO :LT028-DIA-VENC-DEMAIS-PARCELAS
            FROM SEGUROS.LT_PREMIO
            WHERE NUM_PROPOSTA_SIM = :LT028-NUM-PROPOSTA-SIM
            AND IND_TIPO_VIGENCIA = :LT028-IND-TIPO-VIGENCIA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DIA_VENC_DEMAIS_PARCELAS
											FROM SEGUROS.LT_PREMIO
											WHERE NUM_PROPOSTA_SIM = '{this.LT028_NUM_PROPOSTA_SIM}'
											AND IND_TIPO_VIGENCIA = '{this.LT028_IND_TIPO_VIGENCIA}'
											WITH UR";

            return query;
        }
        public string LT028_DIA_VENC_DEMAIS_PARCELAS { get; set; }
        public string LT028_IND_TIPO_VIGENCIA { get; set; }
        public string LT028_NUM_PROPOSTA_SIM { get; set; }

        public static B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1 Execute(B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1 b2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1)
        {
            var ths = b2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1();
            var i = 0;
            dta.LT028_DIA_VENC_DEMAIS_PARCELAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}