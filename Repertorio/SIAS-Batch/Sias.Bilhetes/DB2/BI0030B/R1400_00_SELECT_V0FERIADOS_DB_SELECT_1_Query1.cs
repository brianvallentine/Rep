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
    public class R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_FERIADO ,
            TIPO_FERIADO ,
            SIT_REGISTRO
            INTO :V0FERI-DTMOVTO ,
            :V0FERI-TIPO ,
            :V0FERI-SITUACAO
            FROM SEGUROS.V0FERIADOS
            WHERE DATA_FERIADO = :V0CALE-DTMOVTO
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_FERIADO 
							,
											TIPO_FERIADO 
							,
											SIT_REGISTRO
											FROM SEGUROS.V0FERIADOS
											WHERE DATA_FERIADO = '{this.V0CALE_DTMOVTO}'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string V0FERI_DTMOVTO { get; set; }
        public string V0FERI_TIPO { get; set; }
        public string V0FERI_SITUACAO { get; set; }
        public string V0CALE_DTMOVTO { get; set; }

        public static R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1 r1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_V0FERIADOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FERI_DTMOVTO = result[i++].Value?.ToString();
            dta.V0FERI_TIPO = result[i++].Value?.ToString();
            dta.V0FERI_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}