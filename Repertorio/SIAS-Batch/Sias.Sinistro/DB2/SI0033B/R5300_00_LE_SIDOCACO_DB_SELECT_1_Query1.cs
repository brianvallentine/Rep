using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0033B
{
    public class R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1 : QueryBasis<R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(A.DATA_MOVTO_DOCACO)
            INTO :SIDOCACO-DATA-MOVTO-DOCACO
            FROM SEGUROS.SI_DOCUMENTO_ACOMP A,
            SEGUROS.SI_DOCUMENTO_PARAM B
            WHERE A.COD_FONTE = :SIDOCACO-COD-FONTE
            AND A.NUM_PROTOCOLO_SINI =
            :SIDOCACO-NUM-PROTOCOLO-SINI
            AND A.DAC_PROTOCOLO_SINI =
            :SIDOCACO-DAC-PROTOCOLO-SINI
            AND B.COD_TIPO_CARTA =
            :SIDOCPAR-COD-TIPO-CARTA
            AND A.COD_PRODUTO = B.COD_PRODUTO
            AND A.COD_GRUPO_CAUSA = B.COD_GRUPO_CAUSA
            AND A.COD_SUBGRUPO_CAUSA = B.COD_SUBGRUPO_CAUSA
            AND A.COD_DOCUMENTO = B.COD_DOCUMENTO
            AND A.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR
            AND B.OPCAO_DOCUMENTO IN ( '1' , '3' )
            AND A.NUM_OCORR_DOCACO =
            (SELECT MIN(C.NUM_OCORR_DOCACO)
            FROM SEGUROS.SI_DOCUMENTO_ACOMP C
            WHERE C.COD_FONTE = A.COD_FONTE
            AND C.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI
            AND C.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI
            AND C.COD_DOCUMENTO = A.COD_DOCUMENTO
            AND C.COD_EVENTO IN (2012, 2013))
            AND EXISTS
            (SELECT *
            FROM SEGUROS.SI_DOCUMENTO_ACOMP D,
            SEGUROS.SI_DOCUMENTO_PARAM E
            WHERE E.COD_TIPO_CARTA = B.COD_TIPO_CARTA
            AND E.OPCAO_DOCUMENTO = B.OPCAO_DOCUMENTO
            AND D.COD_PRODUTO = E.COD_PRODUTO
            AND D.COD_GRUPO_CAUSA = E.COD_GRUPO_CAUSA
            AND D.COD_SUBGRUPO_CAUSA = E.COD_SUBGRUPO_CAUSA
            AND D.COD_DOCUMENTO = E.COD_DOCUMENTO
            AND D.DATA_INIVIG_DOCPAR = E.DATA_INIVIG_DOCPAR
            AND D.COD_FONTE = A.COD_FONTE
            AND D.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI
            AND D.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI
            AND D.COD_DOCUMENTO = A.COD_DOCUMENTO
            AND D.COD_EVENTO IN (2012, 2013)
            AND D.NUM_OCORR_DOCACO =
            (SELECT MAX(E.NUM_OCORR_DOCACO)
            FROM SEGUROS.SI_DOCUMENTO_ACOMP E
            WHERE E.COD_FONTE = D.COD_FONTE
            AND E.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI
            AND E.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI
            AND E.COD_DOCUMENTO = D.COD_DOCUMENTO
            AND D.DATA_INIVIG_DOCPAR = E.DATA_INIVIG_DOCPAR))
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MIN(A.DATA_MOVTO_DOCACO)
											FROM SEGUROS.SI_DOCUMENTO_ACOMP A
							,
											SEGUROS.SI_DOCUMENTO_PARAM B
											WHERE A.COD_FONTE = '{this.SIDOCACO_COD_FONTE}'
											AND A.NUM_PROTOCOLO_SINI =
											'{this.SIDOCACO_NUM_PROTOCOLO_SINI}'
											AND A.DAC_PROTOCOLO_SINI =
											'{this.SIDOCACO_DAC_PROTOCOLO_SINI}'
											AND B.COD_TIPO_CARTA =
											'{this.SIDOCPAR_COD_TIPO_CARTA}'
											AND A.COD_PRODUTO = B.COD_PRODUTO
											AND A.COD_GRUPO_CAUSA = B.COD_GRUPO_CAUSA
											AND A.COD_SUBGRUPO_CAUSA = B.COD_SUBGRUPO_CAUSA
											AND A.COD_DOCUMENTO = B.COD_DOCUMENTO
											AND A.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR
											AND B.OPCAO_DOCUMENTO IN ( '1' 
							, '3' )
											AND A.NUM_OCORR_DOCACO =
											(SELECT MIN(C.NUM_OCORR_DOCACO)
											FROM SEGUROS.SI_DOCUMENTO_ACOMP C
											WHERE C.COD_FONTE = A.COD_FONTE
											AND C.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI
											AND C.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI
											AND C.COD_DOCUMENTO = A.COD_DOCUMENTO
											AND C.COD_EVENTO IN (2012
							, 2013))
											AND EXISTS
											(SELECT *
											FROM SEGUROS.SI_DOCUMENTO_ACOMP D
							,
											SEGUROS.SI_DOCUMENTO_PARAM E
											WHERE E.COD_TIPO_CARTA = B.COD_TIPO_CARTA
											AND E.OPCAO_DOCUMENTO = B.OPCAO_DOCUMENTO
											AND D.COD_PRODUTO = E.COD_PRODUTO
											AND D.COD_GRUPO_CAUSA = E.COD_GRUPO_CAUSA
											AND D.COD_SUBGRUPO_CAUSA = E.COD_SUBGRUPO_CAUSA
											AND D.COD_DOCUMENTO = E.COD_DOCUMENTO
											AND D.DATA_INIVIG_DOCPAR = E.DATA_INIVIG_DOCPAR
											AND D.COD_FONTE = A.COD_FONTE
											AND D.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI
											AND D.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI
											AND D.COD_DOCUMENTO = A.COD_DOCUMENTO
											AND D.COD_EVENTO IN (2012
							, 2013)
											AND D.NUM_OCORR_DOCACO =
											(SELECT MAX(E.NUM_OCORR_DOCACO)
											FROM SEGUROS.SI_DOCUMENTO_ACOMP E
											WHERE E.COD_FONTE = D.COD_FONTE
											AND E.NUM_PROTOCOLO_SINI = D.NUM_PROTOCOLO_SINI
											AND E.DAC_PROTOCOLO_SINI = D.DAC_PROTOCOLO_SINI
											AND E.COD_DOCUMENTO = D.COD_DOCUMENTO
											AND D.DATA_INIVIG_DOCPAR = E.DATA_INIVIG_DOCPAR))";

            return query;
        }
        public string SIDOCACO_DATA_MOVTO_DOCACO { get; set; }
        public string SIDOCACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SIDOCACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIDOCPAR_COD_TIPO_CARTA { get; set; }
        public string SIDOCACO_COD_FONTE { get; set; }

        public static R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1 Execute(R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1 r5300_00_LE_SIDOCACO_DB_SELECT_1_Query1)
        {
            var ths = r5300_00_LE_SIDOCACO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5300_00_LE_SIDOCACO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIDOCACO_DATA_MOVTO_DOCACO = result[i++].Value?.ToString();
            return dta;
        }

    }
}