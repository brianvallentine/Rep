using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.COD_SUBGRUPO ,
            B.NUM_PROPOSTA_SIVPF ,
            B.COD_PESSOA ,
            B.NUM_SICOB ,
            B.OPCAO_COBER ,
            B.DATA_PROPOSTA ,
            B.DTQITBCO
            INTO
            :PROPSSVD-NUM-APOLICE ,
            :PROPSSVD-COD-SUBGRUPO ,
            :PROPOFID-NUM-PROPOSTA-SIVPF ,
            :PROPOFID-COD-PESSOA ,
            :PROPOFID-NUM-SICOB ,
            :PROPOFID-OPCAO-COBER ,
            :PROPOFID-DATA-PROPOSTA ,
            :PROPOFID-DTQITBCO
            FROM SEGUROS.PROP_SASSE_VIDA A ,
            SEGUROS.PROPOSTA_FIDELIZ B
            WHERE B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO
            AND B.NUM_PROPOSTA_SIVPF = :ERRPROVI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.COD_SUBGRUPO 
							,
											B.NUM_PROPOSTA_SIVPF 
							,
											B.COD_PESSOA 
							,
											B.NUM_SICOB 
							,
											B.OPCAO_COBER 
							,
											B.DATA_PROPOSTA 
							,
											B.DTQITBCO
											FROM SEGUROS.PROP_SASSE_VIDA A 
							,
											SEGUROS.PROPOSTA_FIDELIZ B
											WHERE B.NUM_IDENTIFICACAO = A.NUM_IDENTIFICACAO
											AND B.NUM_PROPOSTA_SIVPF = '{this.ERRPROVI_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_DATA_PROPOSTA { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string ERRPROVI_NUM_CERTIFICADO { get; set; }

        public static R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1 Execute(R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1 r1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPSSVD_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPSSVD_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.PROPOFID_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_DTQITBCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}