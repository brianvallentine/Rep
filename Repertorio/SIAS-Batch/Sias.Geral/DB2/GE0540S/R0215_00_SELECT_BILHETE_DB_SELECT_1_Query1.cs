using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_AGENCIA_DEB ,
            B.OPERACAO_CONTA_DEB ,
            B.NUM_CONTA_DEB ,
            B.DIG_CONTA_DEB
            INTO :BILHETE-COD-AGENCIA-DEB ,
            :BILHETE-OPERACAO-CONTA-DEB ,
            :BILHETE-NUM-CONTA-DEB ,
            :BILHETE-DIG-CONTA-DEB
            FROM SEGUROS.BILHETE_ENDOSSO A,
            SEGUROS.BILHETE B
            WHERE A.NUM_APOLICE = :APOLCOBR-NUM-APOLICE
            AND A.NUM_ENDOSSO = :APOLCOBR-NUM-ENDOSSO
            AND A.NUM_BILHETE = B.NUM_BILHETE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_AGENCIA_DEB 
							,
											B.OPERACAO_CONTA_DEB 
							,
											B.NUM_CONTA_DEB 
							,
											B.DIG_CONTA_DEB
											FROM SEGUROS.BILHETE_ENDOSSO A
							,
											SEGUROS.BILHETE B
											WHERE A.NUM_APOLICE = '{this.APOLCOBR_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.APOLCOBR_NUM_ENDOSSO}'
											AND A.NUM_BILHETE = B.NUM_BILHETE
											WITH UR";

            return query;
        }
        public string BILHETE_COD_AGENCIA_DEB { get; set; }
        public string BILHETE_OPERACAO_CONTA_DEB { get; set; }
        public string BILHETE_NUM_CONTA_DEB { get; set; }
        public string BILHETE_DIG_CONTA_DEB { get; set; }
        public string APOLCOBR_NUM_APOLICE { get; set; }
        public string APOLCOBR_NUM_ENDOSSO { get; set; }

        public static R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1 r0215_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0215_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0215_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_OPERACAO_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            return dta;
        }

    }
}