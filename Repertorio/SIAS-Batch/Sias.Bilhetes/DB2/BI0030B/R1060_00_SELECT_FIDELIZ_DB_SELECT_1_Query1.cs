using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0030B
{
    public class R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF,
            ORIGEM_PROPOSTA,
            NUM_SICOB,
            SIT_PROPOSTA
            INTO :V0CONV-NUM-PROPOSTA-SIVPF ,
            :V0CONV-ORIGEM-PROPOSTA ,
            :V0CONV-NUM-SICOB,
            :V0SIVPF-SIT-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :V1BILH-NUMBIL
            AND ( COD_PRODUTO_SIVPF IN (09,10)
            OR ( COD_PRODUTO_SIVPF BETWEEN 8100 AND 8199 )
            OR ( COD_PRODUTO_SIVPF BETWEEN 8500 AND 8599 ) )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
							,
											ORIGEM_PROPOSTA
							,
											NUM_SICOB
							,
											SIT_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.V1BILH_NUMBIL}'
											AND ( COD_PRODUTO_SIVPF IN (09
							,10)
											OR ( COD_PRODUTO_SIVPF BETWEEN 8100 AND 8199 )
											OR ( COD_PRODUTO_SIVPF BETWEEN 8500 AND 8599 ) )";

            return query;
        }
        public string V0CONV_NUM_PROPOSTA_SIVPF { get; set; }
        public string V0CONV_ORIGEM_PROPOSTA { get; set; }
        public string V0CONV_NUM_SICOB { get; set; }
        public string V0SIVPF_SIT_PROPOSTA { get; set; }
        public string V1BILH_NUMBIL { get; set; }

        public static R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 Execute(R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 r1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1060_00_SELECT_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CONV_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.V0CONV_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.V0CONV_NUM_SICOB = result[i++].Value?.ToString();
            dta.V0SIVPF_SIT_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}