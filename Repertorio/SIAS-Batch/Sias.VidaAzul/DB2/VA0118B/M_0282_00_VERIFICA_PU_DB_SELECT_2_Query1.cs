using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1 : QueryBasis<M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE, NUM_ITEM
            INTO :SEGURVGA-NUM-APOLICE
            , :SEGURVGA-NUM-ITEM
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO-RISCO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							, NUM_ITEM
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.WS_NUM_CERTIFICADO_RISCO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string WS_NUM_CERTIFICADO_RISCO { get; set; }

        public static M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1 Execute(M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1 m_0282_00_VERIFICA_PU_DB_SELECT_2_Query1)
        {
            var ths = m_0282_00_VERIFICA_PU_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0282_00_VERIFICA_PU_DB_SELECT_2_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}