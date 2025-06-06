using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB,
            SIT_PROPOSTA,
            NUM_PROPOSTA_SIVPF,
            COD_PRODUTO_SIVPF,
            ORIGEM_PROPOSTA ,
            DIGCTAVEN ,
            NUMCTAVEN ,
            OPCAO_COBER ,
            DIA_DEBITO ,
            NUM_IDENTIFICACAO
            INTO :V0CONV-NUM-SICOB,
            :V0SIVPF-SIT-PROPOSTA,
            :V0CONV-NUM-PROPOSTA-SIVPF,
            :PRPFIDEL-COD-PROD-SIVPF,
            :PRPFIDEL-ORIG-PROPOSTA,
            :PRPFIDEL-QTD-MESES ,
            :PRPFIDEL-PERIPGTO ,
            :PRPFIDEL-OPCAO-COBER ,
            :PRPFIDEL-DIA-DEBITO ,
            :PRPFIDEL-NUM-IDENTIFICA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :V0BILH-NUMBIL
            AND COD_PRODUTO_SIVPF = 09
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
							,
											SIT_PROPOSTA
							,
											NUM_PROPOSTA_SIVPF
							,
											COD_PRODUTO_SIVPF
							,
											ORIGEM_PROPOSTA 
							,
											DIGCTAVEN 
							,
											NUMCTAVEN 
							,
											OPCAO_COBER 
							,
											DIA_DEBITO 
							,
											NUM_IDENTIFICACAO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.V0BILH_NUMBIL}'
											AND COD_PRODUTO_SIVPF = 09
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0CONV_NUM_SICOB { get; set; }
        public string V0SIVPF_SIT_PROPOSTA { get; set; }
        public string V0CONV_NUM_PROPOSTA_SIVPF { get; set; }
        public string PRPFIDEL_COD_PROD_SIVPF { get; set; }
        public string PRPFIDEL_ORIG_PROPOSTA { get; set; }
        public string PRPFIDEL_QTD_MESES { get; set; }
        public string PRPFIDEL_PERIPGTO { get; set; }
        public string PRPFIDEL_OPCAO_COBER { get; set; }
        public string PRPFIDEL_DIA_DEBITO { get; set; }
        public string PRPFIDEL_NUM_IDENTIFICA { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0260_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CONV_NUM_SICOB = result[i++].Value?.ToString();
            dta.V0SIVPF_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.V0CONV_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PRPFIDEL_COD_PROD_SIVPF = result[i++].Value?.ToString();
            dta.PRPFIDEL_ORIG_PROPOSTA = result[i++].Value?.ToString();
            dta.PRPFIDEL_QTD_MESES = result[i++].Value?.ToString();
            dta.PRPFIDEL_PERIPGTO = result[i++].Value?.ToString();
            dta.PRPFIDEL_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PRPFIDEL_DIA_DEBITO = result[i++].Value?.ToString();
            dta.PRPFIDEL_NUM_IDENTIFICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}