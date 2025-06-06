using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1 : QueryBasis<R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FUNDOCOMISVA
            (CODPRODU ,
            NRCERTIF ,
            NRPROPAZ ,
            NUM_TERMO,
            SITUACAO ,
            CODOPER ,
            FONTE ,
            AGENCIA ,
            CODCLIEN ,
            NRMATRVEN,
            VLBASVG ,
            VALBASAP ,
            VLCOMISVG,
            VLCOMISAP,
            DTQITBCO ,
            PCCOMIND ,
            PCCOMGER ,
            PCCOMSUP ,
            DTMOVTO ,
            COD_USUARIO,
            TIMESTAMP,
            NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_ENDOSSO,
            NUM_TITULO,
            NUM_PARCELA)
            VALUES (:VGPROSIA-COD-PRODUTO,
            0,
            0,
            :TERMOADE-NUM-TERMO,
            '0' ,
            1101,
            :SUBGVGAP-COD-FONTE,
            :TERMOADE-COD-AGENCIA-OP,
            :SUBGVGAP-COD-CLIENTE,
            :TERMOADE-NUM-MATRICULA-VEN,
            :V0HCTVA-PRMVG,
            :V0HCTVA-PRMAP,
            :V0FUND-VLCOMISVG,
            :V0FUND-VLCOMISAP,
            :V0HCOB-DTVENCTO,
            :PARAGEEM-PCCOMVEN,
            0,
            0,
            :V0SIST-DTMOVABE,
            'VA0813B' ,
            CURRENT TIMESTAMP,
            :V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            0,
            :V0HCOB-NRTIT,
            :V0HCTA-NRPARCEL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP, NUM_APOLICE, COD_SUBGRUPO, NUM_ENDOSSO, NUM_TITULO, NUM_PARCELA) VALUES ({FieldThreatment(this.VGPROSIA_COD_PRODUTO)}, 0, 0, {FieldThreatment(this.TERMOADE_NUM_TERMO)}, '0' , 1101, {FieldThreatment(this.SUBGVGAP_COD_FONTE)}, {FieldThreatment(this.TERMOADE_COD_AGENCIA_OP)}, {FieldThreatment(this.SUBGVGAP_COD_CLIENTE)}, {FieldThreatment(this.TERMOADE_NUM_MATRICULA_VEN)}, {FieldThreatment(this.V0HCTVA_PRMVG)}, {FieldThreatment(this.V0HCTVA_PRMAP)}, {FieldThreatment(this.V0FUND_VLCOMISVG)}, {FieldThreatment(this.V0FUND_VLCOMISAP)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, {FieldThreatment(this.PARAGEEM_PCCOMVEN)}, 0, 0, {FieldThreatment(this.V0SIST_DTMOVABE)}, 'VA0813B' , CURRENT TIMESTAMP, {FieldThreatment(this.V0PROP_NUM_APOLICE)}, {FieldThreatment(this.V0PROP_CODSUBES)}, 0, {FieldThreatment(this.V0HCOB_NRTIT)}, {FieldThreatment(this.V0HCTA_NRPARCEL)})";

            return query;
        }
        public string VGPROSIA_COD_PRODUTO { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string TERMOADE_COD_AGENCIA_OP { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string V0HCTVA_PRMVG { get; set; }
        public string V0HCTVA_PRMAP { get; set; }
        public string V0FUND_VLCOMISVG { get; set; }
        public string V0FUND_VLCOMISAP { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string PARAGEEM_PCCOMVEN { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static void Execute(R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1 r0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1)
        {
            var ths = r0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}