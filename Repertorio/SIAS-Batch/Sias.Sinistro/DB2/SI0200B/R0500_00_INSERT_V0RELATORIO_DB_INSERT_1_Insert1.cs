using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0200B
{
    public class R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES (:V0RELA-CODUSU ,
            :V0RELA-DT-SOLIC ,
            :V0RELA-IDSISTEM ,
            :V0RELA-CODRELAT ,
            :V0RELA-NRCOPIAS ,
            :V0RELA-QTDE ,
            :V0RELA-PERI-INIC ,
            :V0RELA-PERI-FINAL ,
            :V0RELA-DATA-REFER ,
            :V0RELA-MES-REFER ,
            :V0RELA-ANO-REFER ,
            :V0RELA-ORGAO ,
            :V0RELA-FONTE ,
            :V0RELA-CODPDT ,
            :V0RELA-RAMO ,
            :V0RELA-MODALID ,
            :V0RELA-CONGENER ,
            :V0RELA-NUM-APOL ,
            :V0RELA-NRENDOS ,
            :V0RELA-NRPARCEL ,
            :V0RELA-NRCERTIF ,
            :V0RELA-NRTIT ,
            :V0RELA-CODSUBES ,
            :V0RELA-OPERACAO ,
            :V0RELA-COD-PLANO ,
            :V0RELA-OCORHIST ,
            :V0RELA-APOL-LIDER ,
            :V0RELA-ENDS-LIDER ,
            :V0RELA-NRPARC-LID ,
            :V0RELA-NUM-SINIST ,
            :V0RELA-NSINI-LID ,
            :V0RELA-NUM-ORDEM ,
            :V0RELA-CODUNIMO ,
            :V0RELA-CORRECAO ,
            :V0RELA-SITUACAO ,
            :V0RELA-PRV-DEF ,
            :V0RELA-ANAL-RESU ,
            :V0RELA-COD-EMPR:VIND-COD-EMPR ,
            :V0RELA-PERI-RENOV:VIND-PERI-RENOV ,
            :V0RELA-PCT-AUMENTO:VIND-PCT-AUMENTO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ({FieldThreatment(this.V0RELA_CODUSU)} , {FieldThreatment(this.V0RELA_DT_SOLIC)} , {FieldThreatment(this.V0RELA_IDSISTEM)} , {FieldThreatment(this.V0RELA_CODRELAT)} , {FieldThreatment(this.V0RELA_NRCOPIAS)} , {FieldThreatment(this.V0RELA_QTDE)} , {FieldThreatment(this.V0RELA_PERI_INIC)} , {FieldThreatment(this.V0RELA_PERI_FINAL)} , {FieldThreatment(this.V0RELA_DATA_REFER)} , {FieldThreatment(this.V0RELA_MES_REFER)} , {FieldThreatment(this.V0RELA_ANO_REFER)} , {FieldThreatment(this.V0RELA_ORGAO)} , {FieldThreatment(this.V0RELA_FONTE)} , {FieldThreatment(this.V0RELA_CODPDT)} , {FieldThreatment(this.V0RELA_RAMO)} , {FieldThreatment(this.V0RELA_MODALID)} , {FieldThreatment(this.V0RELA_CONGENER)} , {FieldThreatment(this.V0RELA_NUM_APOL)} , {FieldThreatment(this.V0RELA_NRENDOS)} , {FieldThreatment(this.V0RELA_NRPARCEL)} , {FieldThreatment(this.V0RELA_NRCERTIF)} , {FieldThreatment(this.V0RELA_NRTIT)} , {FieldThreatment(this.V0RELA_CODSUBES)} , {FieldThreatment(this.V0RELA_OPERACAO)} , {FieldThreatment(this.V0RELA_COD_PLANO)} , {FieldThreatment(this.V0RELA_OCORHIST)} , {FieldThreatment(this.V0RELA_APOL_LIDER)} , {FieldThreatment(this.V0RELA_ENDS_LIDER)} , {FieldThreatment(this.V0RELA_NRPARC_LID)} , {FieldThreatment(this.V0RELA_NUM_SINIST)} , {FieldThreatment(this.V0RELA_NSINI_LID)} , {FieldThreatment(this.V0RELA_NUM_ORDEM)} , {FieldThreatment(this.V0RELA_CODUNIMO)} , {FieldThreatment(this.V0RELA_CORRECAO)} , {FieldThreatment(this.V0RELA_SITUACAO)} , {FieldThreatment(this.V0RELA_PRV_DEF)} , {FieldThreatment(this.V0RELA_ANAL_RESU)} ,  {FieldThreatment((this.VIND_COD_EMPR?.ToInt() == -1 ? null : this.V0RELA_COD_EMPR))} ,  {FieldThreatment((this.VIND_PERI_RENOV?.ToInt() == -1 ? null : this.V0RELA_PERI_RENOV))} ,  {FieldThreatment((this.VIND_PCT_AUMENTO?.ToInt() == -1 ? null : this.V0RELA_PCT_AUMENTO))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RELA_CODUSU { get; set; }
        public string V0RELA_DT_SOLIC { get; set; }
        public string V0RELA_IDSISTEM { get; set; }
        public string V0RELA_CODRELAT { get; set; }
        public string V0RELA_NRCOPIAS { get; set; }
        public string V0RELA_QTDE { get; set; }
        public string V0RELA_PERI_INIC { get; set; }
        public string V0RELA_PERI_FINAL { get; set; }
        public string V0RELA_DATA_REFER { get; set; }
        public string V0RELA_MES_REFER { get; set; }
        public string V0RELA_ANO_REFER { get; set; }
        public string V0RELA_ORGAO { get; set; }
        public string V0RELA_FONTE { get; set; }
        public string V0RELA_CODPDT { get; set; }
        public string V0RELA_RAMO { get; set; }
        public string V0RELA_MODALID { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_NUM_APOL { get; set; }
        public string V0RELA_NRENDOS { get; set; }
        public string V0RELA_NRPARCEL { get; set; }
        public string V0RELA_NRCERTIF { get; set; }
        public string V0RELA_NRTIT { get; set; }
        public string V0RELA_CODSUBES { get; set; }
        public string V0RELA_OPERACAO { get; set; }
        public string V0RELA_COD_PLANO { get; set; }
        public string V0RELA_OCORHIST { get; set; }
        public string V0RELA_APOL_LIDER { get; set; }
        public string V0RELA_ENDS_LIDER { get; set; }
        public string V0RELA_NRPARC_LID { get; set; }
        public string V0RELA_NUM_SINIST { get; set; }
        public string V0RELA_NSINI_LID { get; set; }
        public string V0RELA_NUM_ORDEM { get; set; }
        public string V0RELA_CODUNIMO { get; set; }
        public string V0RELA_CORRECAO { get; set; }
        public string V0RELA_SITUACAO { get; set; }
        public string V0RELA_PRV_DEF { get; set; }
        public string V0RELA_ANAL_RESU { get; set; }
        public string V0RELA_COD_EMPR { get; set; }
        public string VIND_COD_EMPR { get; set; }
        public string V0RELA_PERI_RENOV { get; set; }
        public string VIND_PERI_RENOV { get; set; }
        public string V0RELA_PCT_AUMENTO { get; set; }
        public string VIND_PCT_AUMENTO { get; set; }

        public static void Execute(R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1 r0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = r0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}