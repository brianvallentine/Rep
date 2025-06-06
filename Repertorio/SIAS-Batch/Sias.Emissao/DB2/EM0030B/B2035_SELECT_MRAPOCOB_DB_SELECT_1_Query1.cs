using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1 : QueryBasis<B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(A.PRM_TARIFARIO_IX),0)
            INTO :MRAPOCOB-PRM-TARIFARIO-IX
            FROM SEGUROS.MR_APOLICE_COBER A
            WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE
            AND A.NUM_ENDOSSO = :ENDO-NRENDOS
            AND A.COD_COBERTURA = 99
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(A.PRM_TARIFARIO_IX)
							,0)
											FROM SEGUROS.MR_APOLICE_COBER A
											WHERE A.NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND A.COD_COBERTURA = 99
											WITH UR";

            return query;
        }
        public string MRAPOCOB_PRM_TARIFARIO_IX { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1 Execute(B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1 b2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1)
        {
            var ths = b2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.MRAPOCOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}