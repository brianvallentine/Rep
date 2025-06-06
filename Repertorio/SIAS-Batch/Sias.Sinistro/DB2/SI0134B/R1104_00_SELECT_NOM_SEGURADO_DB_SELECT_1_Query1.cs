using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0134B
{
    public class R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPRIET
            INTO :APOLICRE-PROPRIET
            FROM SEGUROS.APOLICE_CREDITO TB1,
            SEGUROS.SINISTRO_CRED_INT TB2
            WHERE TB2.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND TB2.COD_SUREG = TB1.COD_SUREG
            AND TB2.COD_AGENCIA = TB1.COD_AGENCIA
            AND TB2.COD_OPERACAO = TB1.COD_OPERACAO
            AND TB2.NUM_CONTRATO = TB1.NUM_CONTRATO
            AND TB2.CONTRATO_DIGITO = TB1.CONTRATO_DIGITO
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPRIET
											FROM SEGUROS.APOLICE_CREDITO TB1
							,
											SEGUROS.SINISTRO_CRED_INT TB2
											WHERE TB2.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND TB2.COD_SUREG = TB1.COD_SUREG
											AND TB2.COD_AGENCIA = TB1.COD_AGENCIA
											AND TB2.COD_OPERACAO = TB1.COD_OPERACAO
											AND TB2.NUM_CONTRATO = TB1.NUM_CONTRATO
											AND TB2.CONTRATO_DIGITO = TB1.CONTRATO_DIGITO
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string APOLICRE_PROPRIET { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 Execute(R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 r1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1104_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICRE_PROPRIET = result[i++].Value?.ToString();
            return dta;
        }

    }
}