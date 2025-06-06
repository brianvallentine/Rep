using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1 : QueryBasis<M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_AGENCIA,
            B.OPERACAO_CONTA,
            B.NUM_CONTA,
            B.DIG_CONTA
            INTO :FUNCEF-AGENCIA,
            :FUNCEF-OPERACAO,
            :FUNCEF-CONTA,
            :FUNCEF-DIG
            FROM SEGUROS.V0PRODUTOR A,
            SEGUROS.V0FUNCIOCEF B
            WHERE A.CODPDT = :MVCOM-CODPDT
            AND B.NUM_MATRICULA = A.CHPFUN
            AND B.NUM_CPF = A.CGCCPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_AGENCIA
							,
											B.OPERACAO_CONTA
							,
											B.NUM_CONTA
							,
											B.DIG_CONTA
											FROM SEGUROS.V0PRODUTOR A
							,
											SEGUROS.V0FUNCIOCEF B
											WHERE A.CODPDT = '{this.MVCOM_CODPDT}'
											AND B.NUM_MATRICULA = A.CHPFUN
											AND B.NUM_CPF = A.CGCCPF
											WITH UR";

            return query;
        }
        public string FUNCEF_AGENCIA { get; set; }
        public string FUNCEF_OPERACAO { get; set; }
        public string FUNCEF_CONTA { get; set; }
        public string FUNCEF_DIG { get; set; }
        public string MVCOM_CODPDT { get; set; }

        public static M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1 Execute(M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1 m_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1)
        {
            var ths = m_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1232_REJEITA_COMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCEF_AGENCIA = result[i++].Value?.ToString();
            dta.FUNCEF_OPERACAO = result[i++].Value?.ToString();
            dta.FUNCEF_CONTA = result[i++].Value?.ToString();
            dta.FUNCEF_DIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}