using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1651B
{
    public class R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 : QueryBasis<R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_INCLUSAO,
            COD_AGENCIADOR,
            NUM_ITEM,
            OCORR_HISTORICO,
            LOT_EMP_SEGURADO,
            COD_CLIENTE
            INTO :V0SEGU-TPINCLUS,
            :V0SEGU-AGENCIADOR,
            :V0SEGU-ITEM,
            :V0SEGU-OCORHIST,
            :V0SEGU-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEG,
            :V0SEGU-CODCLIEN
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_INCLUSAO
							,
											COD_AGENCIADOR
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
							,
											LOT_EMP_SEGURADO
							,
											COD_CLIENTE
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string V0SEGU_TPINCLUS { get; set; }
        public string V0SEGU_AGENCIADOR { get; set; }
        public string V0SEGU_ITEM { get; set; }
        public string V0SEGU_OCORHIST { get; set; }
        public string V0SEGU_LOT_EMP_SEGURADO { get; set; }
        public string VIND_LOT_EMP_SEG { get; set; }
        public string V0SEGU_CODCLIEN { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 Execute(R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 r2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1)
        {
            var ths = r2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_CANCELA_SEGURO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0SEGU_TPINCLUS = result[i++].Value?.ToString();
            dta.V0SEGU_AGENCIADOR = result[i++].Value?.ToString();
            dta.V0SEGU_ITEM = result[i++].Value?.ToString();
            dta.V0SEGU_OCORHIST = result[i++].Value?.ToString();
            dta.V0SEGU_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.VIND_LOT_EMP_SEG = string.IsNullOrWhiteSpace(dta.V0SEGU_LOT_EMP_SEGURADO) ? "-1" : "0";
            dta.V0SEGU_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}