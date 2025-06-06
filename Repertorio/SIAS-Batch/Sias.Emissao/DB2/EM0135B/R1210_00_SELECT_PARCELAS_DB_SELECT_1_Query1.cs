using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0135B
{
    public class R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(B.PRM_LIQUIDO_IX), 0),
            VALUE(SUM(B.PRM_TOTAL_IX), 0)
            INTO :PARCELAS-PRM-LIQUIDO-IX,
            :PARCELAS-PRM-TOTAL-IX
            FROM SEGUROS.ENDOSSOS A ,
            SEGUROS.PARCELAS B
            WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND A.TIPO_ENDOSSO IN ( '0' , '1' )
            AND B.SIT_REGISTRO = '1'
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(B.PRM_LIQUIDO_IX)
							, 0)
							,
											VALUE(SUM(B.PRM_TOTAL_IX)
							, 0)
											FROM SEGUROS.ENDOSSOS A 
							,
											SEGUROS.PARCELAS B
											WHERE A.NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND A.TIPO_ENDOSSO IN ( '0' 
							, '1' )
											AND B.SIT_REGISTRO = '1'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO";

            return query;
        }
        public string PARCELAS_PRM_LIQUIDO_IX { get; set; }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }

        public static R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_PRM_LIQUIDO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TOTAL_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}