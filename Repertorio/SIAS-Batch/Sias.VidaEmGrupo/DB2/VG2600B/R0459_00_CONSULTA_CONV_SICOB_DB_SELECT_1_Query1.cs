using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1 : QueryBasis<R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :CONVERSI-NUM-SICOB
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF = '{this.CONVERSI_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string CONVERSI_NUM_SICOB { get; set; }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1 Execute(R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1 r0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1)
        {
            var ths = r0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0459_00_CONSULTA_CONV_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVERSI_NUM_SICOB = result[i++].Value?.ToString();
            return dta;
        }

    }
}