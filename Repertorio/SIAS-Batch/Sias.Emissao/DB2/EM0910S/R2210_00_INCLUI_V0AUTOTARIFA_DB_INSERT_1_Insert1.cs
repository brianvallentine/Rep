using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1 : QueryBasis<R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0AUTOTARIFA
            VALUES (:V0TARI-COD-EMPRESA,
            :V0TARI-FONTE ,
            :V0TARI-NRPROPOS ,
            :V0TARI-NRITEM ,
            :V0TARI-DTINIVIG ,
            :V0TARI-DTTERVIG ,
            :V0TARI-TERCEIXO ,
            :V0TARI-CATTARIF ,
            :V0TARI-TIPOCOB ,
            :V0TARI-REGIAO ,
            :V0TARI-FRANQFAC ,
            :V0TARI-CLABONAT ,
            :V0TARI-PCDESCAT ,
            :V0TARI-CLABONDM ,
            :V0TARI-CLABONDP ,
            :V0TARI-CATTARIR ,
            :V0TARI-DESCFROT ,
            :V0TARI-NUMPASSG ,
            :V0TARI-VRFROBR-IX ,
            :V0TARI-VRFRFACC-IX,
            :V0TARI-VRFRFACA-IX,
            :V0TARI-VRFRADIC-IX,
            :V0TARI-VRPRREF ,
            :V0TARI-CFFROBR ,
            :V0TARI-CFFRFACC ,
            :V0TARI-CFFRFACA ,
            :V0TARI-CFPRREF ,
            :V0TARI-PCDSCFRF ,
            :V0TARI-PCISCASC ,
            :V0TARI-PCINCROU ,
            :V0TARI-PCAGPLCA ,
            :V0TARI-PCAGPLAC ,
            :V0TARI-VRPRRFDM ,
            :V0TARI-VRPRRFDP ,
            :V0TARI-EXTPER ,
            :V0TARI-PERIODO ,
            :V0TARI-PCFRADIC ,
            :V0TARI-PRAZOSEG ,
            :V0TARI-DESCIDAD ,
            :V0TARI-TCFAPLPR ,
            :V0TARI-TPCDSFRF ,
            :V0TARI-TPCDSBAU ,
            :V0TARI-TTXAPLIS ,
            :V0TARI-TPCPZSEG ,
            :V0TARI-TPRBRCDM ,
            :V0TARI-TCFPBRDM ,
            :V0TARI-TPRBRCDP ,
            :V0TARI-TCFPBRDP ,
            :V0TARI-TPCBONDM ,
            :V0TARI-TPCBONDP ,
            :V0TARI-TTXAPPM ,
            :V0TARI-TTXAPPI ,
            :V0TARI-TTXAPPA ,
            :V0TARI-TTXAPPD ,
            :V0TARI-TPCDSAPP ,
            :V0TARI-DATEND ,
            :V0TARI-TPCMAJOR ,
            :V0TARI-PCDESAUT ,
            :V0TARI-PCDESRCF ,
            :V0TARI-PCDESAPP ,
            :V0TARI-PCDESPLCA ,
            :V0TARI-PCDESPLRF ,
            :V0TARI-PCDESPLAP ,
            :V0TARI-PCAGPLRF ,
            :V0TARI-PCAGPLAP ,
            :V0TARI-PCDESACE ,
            :V0TARI-NUM-APOL ,
            :V0TARI-NRENDOS ,
            CURRENT TIMESTAMP ,
            :V0TARI-PCAGISCASC :VIND-PCAGISCASC,
            :V0TARI-VALOR-AVARIA,
            :V0TARI-TPCBONDMO ,
            :V0TARI-TCFPBRDMO ,
            :V0TARI-IND-COML ,
            :V0TARI-PCT-COML ,
            :V0TARI-CODUSU ,
            :V0TARI-IND-VLR-MIN,
            NULL,
            :WHOST-CONGENERE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0AUTOTARIFA VALUES ({FieldThreatment(this.V0TARI_COD_EMPRESA)}, {FieldThreatment(this.V0TARI_FONTE)} , {FieldThreatment(this.V0TARI_NRPROPOS)} , {FieldThreatment(this.V0TARI_NRITEM)} , {FieldThreatment(this.V0TARI_DTINIVIG)} , {FieldThreatment(this.V0TARI_DTTERVIG)} , {FieldThreatment(this.V0TARI_TERCEIXO)} , {FieldThreatment(this.V0TARI_CATTARIF)} , {FieldThreatment(this.V0TARI_TIPOCOB)} , {FieldThreatment(this.V0TARI_REGIAO)} , {FieldThreatment(this.V0TARI_FRANQFAC)} , {FieldThreatment(this.V0TARI_CLABONAT)} , {FieldThreatment(this.V0TARI_PCDESCAT)} , {FieldThreatment(this.V0TARI_CLABONDM)} , {FieldThreatment(this.V0TARI_CLABONDP)} , {FieldThreatment(this.V0TARI_CATTARIR)} , {FieldThreatment(this.V0TARI_DESCFROT)} , {FieldThreatment(this.V0TARI_NUMPASSG)} , {FieldThreatment(this.V0TARI_VRFROBR_IX)} , {FieldThreatment(this.V0TARI_VRFRFACC_IX)}, {FieldThreatment(this.V0TARI_VRFRFACA_IX)}, {FieldThreatment(this.V0TARI_VRFRADIC_IX)}, {FieldThreatment(this.V0TARI_VRPRREF)} , {FieldThreatment(this.V0TARI_CFFROBR)} , {FieldThreatment(this.V0TARI_CFFRFACC)} , {FieldThreatment(this.V0TARI_CFFRFACA)} , {FieldThreatment(this.V0TARI_CFPRREF)} , {FieldThreatment(this.V0TARI_PCDSCFRF)} , {FieldThreatment(this.V0TARI_PCISCASC)} , {FieldThreatment(this.V0TARI_PCINCROU)} , {FieldThreatment(this.V0TARI_PCAGPLCA)} , {FieldThreatment(this.V0TARI_PCAGPLAC)} , {FieldThreatment(this.V0TARI_VRPRRFDM)} , {FieldThreatment(this.V0TARI_VRPRRFDP)} , {FieldThreatment(this.V0TARI_EXTPER)} , {FieldThreatment(this.V0TARI_PERIODO)} , {FieldThreatment(this.V0TARI_PCFRADIC)} , {FieldThreatment(this.V0TARI_PRAZOSEG)} , {FieldThreatment(this.V0TARI_DESCIDAD)} , {FieldThreatment(this.V0TARI_TCFAPLPR)} , {FieldThreatment(this.V0TARI_TPCDSFRF)} , {FieldThreatment(this.V0TARI_TPCDSBAU)} , {FieldThreatment(this.V0TARI_TTXAPLIS)} , {FieldThreatment(this.V0TARI_TPCPZSEG)} , {FieldThreatment(this.V0TARI_TPRBRCDM)} , {FieldThreatment(this.V0TARI_TCFPBRDM)} , {FieldThreatment(this.V0TARI_TPRBRCDP)} , {FieldThreatment(this.V0TARI_TCFPBRDP)} , {FieldThreatment(this.V0TARI_TPCBONDM)} , {FieldThreatment(this.V0TARI_TPCBONDP)} , {FieldThreatment(this.V0TARI_TTXAPPM)} , {FieldThreatment(this.V0TARI_TTXAPPI)} , {FieldThreatment(this.V0TARI_TTXAPPA)} , {FieldThreatment(this.V0TARI_TTXAPPD)} , {FieldThreatment(this.V0TARI_TPCDSAPP)} , {FieldThreatment(this.V0TARI_DATEND)} , {FieldThreatment(this.V0TARI_TPCMAJOR)} , {FieldThreatment(this.V0TARI_PCDESAUT)} , {FieldThreatment(this.V0TARI_PCDESRCF)} , {FieldThreatment(this.V0TARI_PCDESAPP)} , {FieldThreatment(this.V0TARI_PCDESPLCA)} , {FieldThreatment(this.V0TARI_PCDESPLRF)} , {FieldThreatment(this.V0TARI_PCDESPLAP)} , {FieldThreatment(this.V0TARI_PCAGPLRF)} , {FieldThreatment(this.V0TARI_PCAGPLAP)} , {FieldThreatment(this.V0TARI_PCDESACE)} , {FieldThreatment(this.V0TARI_NUM_APOL)} , {FieldThreatment(this.V0TARI_NRENDOS)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_PCAGISCASC?.ToInt() == -1 ? null : this.V0TARI_PCAGISCASC))}, {FieldThreatment(this.V0TARI_VALOR_AVARIA)}, {FieldThreatment(this.V0TARI_TPCBONDMO)} , {FieldThreatment(this.V0TARI_TCFPBRDMO)} , {FieldThreatment(this.V0TARI_IND_COML)} , {FieldThreatment(this.V0TARI_PCT_COML)} , {FieldThreatment(this.V0TARI_CODUSU)} , {FieldThreatment(this.V0TARI_IND_VLR_MIN)}, NULL, {FieldThreatment(this.WHOST_CONGENERE)})";

            return query;
        }
        public string V0TARI_COD_EMPRESA { get; set; }
        public string V0TARI_FONTE { get; set; }
        public string V0TARI_NRPROPOS { get; set; }
        public string V0TARI_NRITEM { get; set; }
        public string V0TARI_DTINIVIG { get; set; }
        public string V0TARI_DTTERVIG { get; set; }
        public string V0TARI_TERCEIXO { get; set; }
        public string V0TARI_CATTARIF { get; set; }
        public string V0TARI_TIPOCOB { get; set; }
        public string V0TARI_REGIAO { get; set; }
        public string V0TARI_FRANQFAC { get; set; }
        public string V0TARI_CLABONAT { get; set; }
        public string V0TARI_PCDESCAT { get; set; }
        public string V0TARI_CLABONDM { get; set; }
        public string V0TARI_CLABONDP { get; set; }
        public string V0TARI_CATTARIR { get; set; }
        public string V0TARI_DESCFROT { get; set; }
        public string V0TARI_NUMPASSG { get; set; }
        public string V0TARI_VRFROBR_IX { get; set; }
        public string V0TARI_VRFRFACC_IX { get; set; }
        public string V0TARI_VRFRFACA_IX { get; set; }
        public string V0TARI_VRFRADIC_IX { get; set; }
        public string V0TARI_VRPRREF { get; set; }
        public string V0TARI_CFFROBR { get; set; }
        public string V0TARI_CFFRFACC { get; set; }
        public string V0TARI_CFFRFACA { get; set; }
        public string V0TARI_CFPRREF { get; set; }
        public string V0TARI_PCDSCFRF { get; set; }
        public string V0TARI_PCISCASC { get; set; }
        public string V0TARI_PCINCROU { get; set; }
        public string V0TARI_PCAGPLCA { get; set; }
        public string V0TARI_PCAGPLAC { get; set; }
        public string V0TARI_VRPRRFDM { get; set; }
        public string V0TARI_VRPRRFDP { get; set; }
        public string V0TARI_EXTPER { get; set; }
        public string V0TARI_PERIODO { get; set; }
        public string V0TARI_PCFRADIC { get; set; }
        public string V0TARI_PRAZOSEG { get; set; }
        public string V0TARI_DESCIDAD { get; set; }
        public string V0TARI_TCFAPLPR { get; set; }
        public string V0TARI_TPCDSFRF { get; set; }
        public string V0TARI_TPCDSBAU { get; set; }
        public string V0TARI_TTXAPLIS { get; set; }
        public string V0TARI_TPCPZSEG { get; set; }
        public string V0TARI_TPRBRCDM { get; set; }
        public string V0TARI_TCFPBRDM { get; set; }
        public string V0TARI_TPRBRCDP { get; set; }
        public string V0TARI_TCFPBRDP { get; set; }
        public string V0TARI_TPCBONDM { get; set; }
        public string V0TARI_TPCBONDP { get; set; }
        public string V0TARI_TTXAPPM { get; set; }
        public string V0TARI_TTXAPPI { get; set; }
        public string V0TARI_TTXAPPA { get; set; }
        public string V0TARI_TTXAPPD { get; set; }
        public string V0TARI_TPCDSAPP { get; set; }
        public string V0TARI_DATEND { get; set; }
        public string V0TARI_TPCMAJOR { get; set; }
        public string V0TARI_PCDESAUT { get; set; }
        public string V0TARI_PCDESRCF { get; set; }
        public string V0TARI_PCDESAPP { get; set; }
        public string V0TARI_PCDESPLCA { get; set; }
        public string V0TARI_PCDESPLRF { get; set; }
        public string V0TARI_PCDESPLAP { get; set; }
        public string V0TARI_PCAGPLRF { get; set; }
        public string V0TARI_PCAGPLAP { get; set; }
        public string V0TARI_PCDESACE { get; set; }
        public string V0TARI_NUM_APOL { get; set; }
        public string V0TARI_NRENDOS { get; set; }
        public string V0TARI_PCAGISCASC { get; set; }
        public string VIND_PCAGISCASC { get; set; }
        public string V0TARI_VALOR_AVARIA { get; set; }
        public string V0TARI_TPCBONDMO { get; set; }
        public string V0TARI_TCFPBRDMO { get; set; }
        public string V0TARI_IND_COML { get; set; }
        public string V0TARI_PCT_COML { get; set; }
        public string V0TARI_CODUSU { get; set; }
        public string V0TARI_IND_VLR_MIN { get; set; }
        public string WHOST_CONGENERE { get; set; }

        public static void Execute(R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1 r2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1)
        {
            var ths = r2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}