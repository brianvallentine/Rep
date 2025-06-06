using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0134B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA ,
            YEAR(DTPROXVEN),
            DTPROXVEN ,
            DATA_VENCIMENTO
            INTO :PROPOVA-NUM-PARCELA,
            :V0PROP-ANO,
            :PROPOVA-DTPROXVEN,
            :PROPOVA-DATA-VENCIMENTO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA 
							,
											YEAR(DTPROXVEN)
							,
											DTPROXVEN 
							,
											DATA_VENCIMENTO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string V0PROP_ANO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1();
            var i = 0;
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.V0PROP_ANO = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}