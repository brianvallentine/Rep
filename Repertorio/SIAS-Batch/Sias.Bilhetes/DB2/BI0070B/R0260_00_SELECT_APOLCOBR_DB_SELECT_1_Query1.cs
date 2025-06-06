using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 : QueryBasis<R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA
            ,COD_AGENCIA_DEB
            ,OPER_CONTA_DEB
            ,NUM_CONTA_DEB
            ,DIG_CONTA_DEB
            ,NUM_CARTAO
            ,DIA_DEBITO
            INTO :APOLCOBR-COD-AGENCIA
            ,:APOLCOBR-COD-AGENCIA-DEB:VIND-AGEDEB
            ,:APOLCOBR-OPER-CONTA-DEB:VIND-OPEDEB
            ,:APOLCOBR-NUM-CONTA-DEB:VIND-NUMDEB
            ,:APOLCOBR-DIG-CONTA-DEB:VIND-DIGDEB
            ,:APOLCOBR-NUM-CARTAO:VIND-CARTAO
            ,:APOLCOBR-DIA-DEBITO:VIND-DIADEB
            FROM SEGUROS.APOLICE_COBRANCA
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
											,COD_AGENCIA_DEB
											,OPER_CONTA_DEB
											,NUM_CONTA_DEB
											,DIG_CONTA_DEB
											,NUM_CARTAO
											,DIA_DEBITO
											FROM SEGUROS.APOLICE_COBRANCA
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string APOLCOBR_COD_AGENCIA { get; set; }
        public string APOLCOBR_COD_AGENCIA_DEB { get; set; }
        public string VIND_AGEDEB { get; set; }
        public string APOLCOBR_OPER_CONTA_DEB { get; set; }
        public string VIND_OPEDEB { get; set; }
        public string APOLCOBR_NUM_CONTA_DEB { get; set; }
        public string VIND_NUMDEB { get; set; }
        public string APOLCOBR_DIG_CONTA_DEB { get; set; }
        public string VIND_DIGDEB { get; set; }
        public string APOLCOBR_NUM_CARTAO { get; set; }
        public string VIND_CARTAO { get; set; }
        public string APOLCOBR_DIA_DEBITO { get; set; }
        public string VIND_DIADEB { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 Execute(R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 r0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1)
        {
            var ths = r0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOBR_COD_AGENCIA = result[i++].Value?.ToString();
            dta.APOLCOBR_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VIND_AGEDEB = string.IsNullOrWhiteSpace(dta.APOLCOBR_COD_AGENCIA_DEB) ? "-1" : "0";
            dta.APOLCOBR_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_OPEDEB = string.IsNullOrWhiteSpace(dta.APOLCOBR_OPER_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NUMDEB = string.IsNullOrWhiteSpace(dta.APOLCOBR_NUM_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_DIGDEB = string.IsNullOrWhiteSpace(dta.APOLCOBR_DIG_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_CARTAO = string.IsNullOrWhiteSpace(dta.APOLCOBR_NUM_CARTAO) ? "-1" : "0";
            dta.APOLCOBR_DIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIADEB = string.IsNullOrWhiteSpace(dta.APOLCOBR_DIA_DEBITO) ? "-1" : "0";
            return dta;
        }

    }
}