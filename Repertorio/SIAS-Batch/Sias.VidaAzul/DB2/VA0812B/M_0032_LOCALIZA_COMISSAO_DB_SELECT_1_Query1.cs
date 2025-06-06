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
    public class M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1 : QueryBasis<M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTOR,
            COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA,
            DATA_MOVIMENTO,
            SITUACAO
            INTO :MVCOM-CODPDT,
            :MVCOM-AGENCIA,
            :MVCOM-OPERACAO,
            :MVCOM-CONTA,
            :MVCOM-DIG,
            :MVCOM-DATA-MOV,
            :MVCOM-SITUACAO
            FROM SEGUROS.V0MOVCOMIS
            WHERE NSAS = :MVCOM-NSAS
            AND NSL = :MVCOM-NSL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTOR
							,
											COD_AGENCIA
							,
											OPERACAO_CONTA
							,
											NUM_CONTA
							,
											DIG_CONTA
							,
											DATA_MOVIMENTO
							,
											SITUACAO
											FROM SEGUROS.V0MOVCOMIS
											WHERE NSAS = '{this.MVCOM_NSAS}'
											AND NSL = '{this.MVCOM_NSL}'
											WITH UR";

            return query;
        }
        public string MVCOM_CODPDT { get; set; }
        public string MVCOM_AGENCIA { get; set; }
        public string MVCOM_OPERACAO { get; set; }
        public string MVCOM_CONTA { get; set; }
        public string MVCOM_DIG { get; set; }
        public string MVCOM_DATA_MOV { get; set; }
        public string MVCOM_SITUACAO { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1 Execute(M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1 m_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1)
        {
            var ths = m_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0032_LOCALIZA_COMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MVCOM_CODPDT = result[i++].Value?.ToString();
            dta.MVCOM_AGENCIA = result[i++].Value?.ToString();
            dta.MVCOM_OPERACAO = result[i++].Value?.ToString();
            dta.MVCOM_CONTA = result[i++].Value?.ToString();
            dta.MVCOM_DIG = result[i++].Value?.ToString();
            dta.MVCOM_DATA_MOV = result[i++].Value?.ToString();
            dta.MVCOM_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}